using CarBook_OnionArch.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CreateCategoryCommandHandler createHandler,
                                  UpdateCategoryCommandHandler updateHandler,
                                  RemoveCategoryCommandHandler removeHandler,
                                  GetCategoryByIdQueryHandler getByIdHandler,
                                  GetCategoryQueryHandler getAllQueryHandler) : ControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var values = await getAllQueryHandler.Handle();

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await getByIdHandler.Handle(new GetCategoryByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            try
            {
                var result = await createHandler.Handle(command);

                if (result == null)
                {
                    return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
                }

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

            }
            catch (Exception ex)
            {
                return BadRequest($"Oluşturma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            try
            {
                var result = await updateHandler.Handle(command);

                if (!result)
                    return BadRequest("Kayıt güncellenirken bir sorun oluştu");

                return Ok("Başarılı şekilde güncellendi");
            }
            catch (Exception ex)
            {
                return BadRequest($"Güncelleme işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await removeHandler.Handle(new RemoveCategoryCommand(id));

                if (!result)
                {
                    return BadRequest($"{id} Id nolu kayıt silinirken bir hata oluştu.");
                }

                return Ok($"{id} Id nolu kayıt başarıyla silindi.");
            }

            catch (Exception ex)
            {
                return BadRequest($"Silme işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }
    }
}
