using apiseguridadvault.Data;
using apiseguridadvault.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiseguridadvault.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadoContext context;

        public RepositoryEmpleados(EmpleadoContext context)
        {
            this.context = context;
        }


        //seguridad
        public async Task<Empleado> LogInEmpleadoAsync(string apellido, int id)
        {
            return await this.context.Empleados
                .Where(x => x.Apellido == apellido && x.IdEmpleado== id).FirstOrDefaultAsync();
        }




        //metodos
        //GET
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }


        //GET CON ID
        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            return await this.context.Empleados.Where(x => x.IdEmpleado == id).FirstOrDefaultAsync();
        }

        //PUT
        public async Task InsertEmpleadoAsync(int id, string apellido, string oficio, int salario, int iddepartamento)
        {
            //construir el objeto
            Empleado empleado = new Empleado();
            empleado.IdEmpleado = id;
            empleado.Apellido = apellido;
            empleado.Oficio = oficio;
            empleado.Salario = salario;
            empleado.IdDepartamento = iddepartamento;
            //AÑADIR
            this.context.Empleados.Add(empleado);
            await this.context.SaveChangesAsync();
        }

        //UPDATE
        public async Task UpdateEmpleadoAsync(int id, string apellido, string oficio, int salario, int iddepartamento)
        {
            //encontrar el empleado
            Empleado empleado = await this.FindEmpleadoAsync(id);
            empleado.Apellido = apellido;
            empleado.Oficio = oficio;
            empleado.Salario = salario;
            empleado.IdDepartamento = iddepartamento;
            await this.context.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteEmpleadoAsync(int id)
        {
            Empleado empleado= await this.FindEmpleadoAsync(id);
            this.context.Empleados.Remove(empleado);
            await this.context.SaveChangesAsync();
        }

    }
}
