using BLL.FacturaConfig;
using DAL;
using Entity;
using JkStoreApi.Models.DetalleFacturasModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JkStoreApi.Models.FacturaModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JkStoreApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService facturaService;
        public FacturaController(JkStoreContext context)
        {
            facturaService = new FacturaService(context);
        }
        // POST api/<FacturaController>
        [HttpPost]
        public ActionResult<Factura> Post([FromBody] FacturaInputModel facturaInput, string evento)
        {
            Factura factura = Mapear(facturaInput);
            var response = facturaService.Guardar(factura, evento);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar factura", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(problemDetails);
            }
            if (evento == "Venta")
            {
                return Ok(new FacturaVentaViewModel(response.Factura));
            }
            return Ok(new FacturaCompraViewModel(response.Factura));
        }

        [HttpGet]
        public ActionResult<Factura> Get()
        {
            var response = facturaService.ConsultarVentas();
            if (response.Error)
            {
                ModelState.AddModelError("Consultar factura", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Facturas.Select(f => new FacturaViewModel(f)));
        }

        private Factura Mapear(FacturaInputModel facturaInput)
        {

            var factura = new Factura
            {
                Proveedor = facturaInput.Proveedor,
                IdInteresado = facturaInput.IdInteresado,
                DetallesDeFactura = MapearDetalles(facturaInput.detallesDeFactura)
            };
            return factura;
        }

        private List<DetalleFactura> MapearDetalles(List<DetalleInputModel> detallesInput) 
        {
            List<DetalleFactura> detallesFactura = new List<DetalleFactura>();
            foreach (var item in detallesInput)
            {
                Producto producto = new Producto();
                producto.Codigo = item.IdProducto;
                var detalle = new DetalleFactura
                {
                    _Producto = producto,
                    Cantidad = item.Cantidad,
                    ValorUnitario = item.ValorUnitario  
                };
                detallesFactura.Add(detalle);
            }
            return detallesFactura;
        }

      
    }
}
