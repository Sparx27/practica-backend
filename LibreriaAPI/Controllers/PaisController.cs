using Compartido.DTOs;
using LogicaAplicacion.Interfaces;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisServicios _paisServicios;
        public PaisController(IPaisServicios paisServicios)
        {
            _paisServicios = paisServicios;
        }

        /// <summary>
        /// Devuelve todos los Paises
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_paisServicios.SelectAllPais());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Buscar Pais por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                PaisDTO? buscar = _paisServicios.SelectPaisById(id);
                if (buscar == null) return NotFound("No se encontro Pais por ese id");
                return Ok(buscar);
            }
            catch(PaisException pex)
            {
                return BadRequest(pex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Permite buscar Pais por su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("nombre/{nombre}")]
        public IActionResult GetByNombre(string nombre)
        {
            try
            {
                PaisDTO? buscar = _paisServicios.SelectPaisByNombre(nombre);
                if (buscar == null) return NotFound("No se encontro Pais con ese nombre");
                return Ok(buscar);
            }
            catch (PaisException pex)
            {
                return BadRequest(pex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Permite crear Pais
        /// </summary>
        /// <param name="paisDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status410Gone)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Post([FromBody] PaisDTO paisDTO)
        {
            try
            {
                _paisServicios.InsertPais(paisDTO);
                return Ok("Creado");
            }
            catch(PaisException pex)
            {
                return BadRequest(pex.Message);
            }
            catch(ConflictException cex)
            {
                return NotFound(cex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Permite borrar Pais buscando por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _paisServicios.DeletePais(id);
                return NoContent();
            }
            catch (PaisException pex)
            {
                return BadRequest(pex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Permite hacer update
        /// </summary>
        /// <param name="paisDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public IActionResult Update([FromBody]PaisDTO paisDTO)
        {
            try
            {
                return Ok(_paisServicios.UpdatePais(paisDTO));
            }
            catch(PaisException pex)
            {
                return BadRequest(pex.Message);
            }
            catch(ConflictException cex)
            {
                return Conflict(cex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
