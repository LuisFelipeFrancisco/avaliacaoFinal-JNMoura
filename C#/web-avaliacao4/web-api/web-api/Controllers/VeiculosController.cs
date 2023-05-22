using System;
using System.Web.Http;

namespace web_api.Controllers
{
    public class VeiculosController : ApiController
    {
        private readonly Repositories.IRepository<Models.Veiculo> repository;
        public VeiculosController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Veiculos(WebApi.Configurations.SQLServer.getConnectionString());
        }

        // GET: api/Veiculos
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.Get());
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // GET: api/Veiculos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Veiculo veiculo = repository.GetById(id);
                if (veiculo == null)
                    return NotFound();
                else
                    return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // POST: api/Veiculos
        public IHttpActionResult Post(Models.Veiculo veiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.Add(veiculo);

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // PUT: api/Veiculos/5
        public IHttpActionResult Put(int id, Models.Veiculo veiculo)
        {
            try
            {
                if (id != veiculo.Id)
                    ModelState.AddModelError("Id", "O id informado na URL é diferente do id informado no corpo da requisição");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.Update(id, veiculo);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Veiculos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = repository.Delete(id);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, WebApi.Configurations.Log.getLogPath());
                return InternalServerError();
            }
        }
    }
}
