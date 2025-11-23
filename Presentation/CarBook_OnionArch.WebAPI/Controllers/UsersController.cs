using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Features.Mediator.Commands.JWTCommands;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppRoleQueries;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_OnionArch.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetAppUsersListQueryResult>>> GetAll()
        {
            var values = await mediator.Send(new GetAppUsersListQuery());

            if (values == null)
            {
                return NotFound("Veri bulunamadı");
            }

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAppUserByIdQueryResult>> GetById(int id)
        {
            var value = await mediator.Send(new GetAppUserByIdQuery(id));

            if (value == null)
            {
                return NotFound("Kayıt bulunamadı");
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult<GetAppUserByIdQueryResult>> Create(CreateAppUserCommand command)
        {
            try
            {
                var isRoleExist = await mediator.Send(new IsAppRoleExistsQuery("User"));
                if (!isRoleExist)
                {
                    return BadRequest("Varsayılan kullanıcı rolü bulunamadı. Lütfen önce 'User' rolünü oluşturun.");
                }
                var createUserResult = await mediator.Send(command);

                if (createUserResult == null)
                {
                    return BadRequest("Oluşturma işlemi sırasında bir sorun oluştu");
                }

                var assignRoleResult = await mediator.Send(new AddAppUserToRoleCommand(createUserResult.Id, "User"));
                if (!assignRoleResult)
                {
                    return BadRequest("Kullanıcı oluşturuldu ancak varsayılan rol atanamadı.");
                }

                return CreatedAtAction(nameof(GetById), new { id = createUserResult.Id }, createUserResult);

            }
            catch (Exception ex)
            {
                return BadRequest($"Oluşturma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<string>> SignIn(AppUserSignInQuery query)
        {
            try
            {
                var user = await mediator.Send(new GetAppUserByUserNameQuery(query.UserName));
                if (user == null)
                {
                    return BadRequest("Bu kullanıcı adıyla kayıtlı bir kullanıcı bulunamadı.");
                }
                var passwordResult = await mediator.Send(new CheckAppUserPasswordQuery(user.Id, query.Password));
                if (!passwordResult)
                {
                    return BadRequest("Geçersiz parola.");
                }

                if (user.UserName == null)
                {
                    return BadRequest("Kullanıcı adı boş olamaz.");
                }
                var token = await mediator.Send(new CreateTokenCommand(user.UserName));
                if (token == null)
                {
                    return BadRequest("Token oluşturulurken bir sorun oluştu.");
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest($"Oturum açma işlemi sırasında bir sorun oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateAppUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("URL'deki id ile gövdedeki id uyuşmuyor.");

            try
            {
                var result = await mediator.Send(command);

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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await mediator.Send(new RemoveAppUserCommand(id));

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