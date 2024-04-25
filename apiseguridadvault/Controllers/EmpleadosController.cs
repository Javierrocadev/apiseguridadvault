using apiseguridadvault.Models;
using apiseguridadvault.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiseguridadvault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        //metodos

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>>
            GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>>FindEmpleado(int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostEmpleado(Empleado empleado)
        {
            await this.repo.InsertEmpleadoAsync(empleado.IdEmpleado,empleado.Apellido,empleado.Oficio,empleado.Salario,empleado.IdDepartamento);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmpleado(int id)
        {
            if (await this.repo.FindEmpleadoAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                await this.repo.DeleteEmpleadoAsync(id);
                return Ok();
            }
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> PutPersonaje(Empleado empleado)
        {
            await this.repo.UpdateEmpleadoAsync(empleado.IdEmpleado, empleado.Apellido, empleado.Oficio, empleado.Salario, empleado.IdDepartamento);
            return Ok();
        }




    }
}
