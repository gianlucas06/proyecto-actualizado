using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SEYNEKUN.Models;

namespace SEYNEKUN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelaController : ControllerBase
    {
        private readonly PanelaService _panelaService;
        public IConfiguration Configuration { get; }
        public PanelaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _panelaService = new PanelaService(connectionString);
        }
        // GET: api/panela
        [HttpGet]
        public IEnumerable<PanelaViewModel> Gets()
        {
            var  panelas = _panelaService.ConsultarTodos().Select(p=> new  PanelaViewModel(p));
            return  panelas;
        }
        // POST: api/panela
        [HttpPost]
        public ActionResult<PanelaViewModel> Post(PanelaInputModel panelaInput)
        {
            Panela panela = MapearPanela(panelaInput);
            var response = _panelaService.Guardar(panela);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Panela);
        }

         // GET: api/panela/5
        [HttpGet("{idregistro}")]
        public ActionResult<PanelaViewModel> Get(string idregistro)
        {
            var panela = _panelaService.BuscarPorIdentificacion(idregistro);
            if (panela == null) return NotFound();
            var panelaViewModel = new PanelaViewModel(panela);
            return panelaViewModel;
        }

        // DELETE: api/panela/5
        [HttpDelete("{idregistro}")]
        public ActionResult<string> Delete(string idregistro)
        {
            string mensaje = _panelaService.Eliminar(idregistro);
            return Ok(mensaje);
        }
        
        private Panela MapearPanela(PanelaInputModel panelaInput)
        {
            var  panela = new Panela
            {
                Idregistro = panelaInput.Idregistro,
                FechaIngreso =  panelaInput.FechaIngreso,
                NumeroLote =  panelaInput.NumeroLote,
                NumeroLoteAgricola =  panelaInput.NumeroLoteAgricola,
                Etapas = panelaInput.Etapas,
                Cantidad= panelaInput.Cantidad,
                Responsable= panelaInput.Responsable,
            };
            return panela;
        }
       
}
}