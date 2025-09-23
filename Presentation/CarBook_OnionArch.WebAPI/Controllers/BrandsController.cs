using CarBook_OnionArch.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_OnionArch.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook_OnionArch.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(CreateBrandCommandHandler createHandler,
                                  UpdateBrandCommandHandler updateHandler,
                                  RemoveBrandCommandHandler removeHandler,
                                  GetBrandByIdQueryHandler getByIdHandler,
                                  GetBrandQueryHandler getAllQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await getAllQueryHandler.Handle();

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await getByIdHandler.Handle(new GetBrandByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateBrandCommand command)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await removeHandler.Handle(new RemoveBrandCommand(id));

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
