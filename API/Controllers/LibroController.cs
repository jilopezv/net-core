using System.Linq.Expressions;
using AutoMapper;
using Data.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[Route("api/libros")]
[ApiController]
public class LibroController : ControllerBase
{
    private readonly IUnitOfWork
        _unitOfWork; // readonly means that the variable can only be assigned a value in the constructor

    private readonly IMapper _mapper;

    public LibroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Create(LibroDto libroDto)
    {
        if (ModelState.IsValid)
        {
            Libro libroAlmacenado = _unitOfWork.Libros.Add(_mapper.Map<Libro>(libroDto));
            _unitOfWork.Complete(); // save the changes to the database

            return Ok(_mapper.Map<LibroDto>(libroAlmacenado));
        }

        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_mapper.Map<IEnumerable<LibroDetalladoDto>>(_unitOfWork.Libros.AllDetails()));
    }

    [HttpGet("{isbn}")]
    public IActionResult GetById(string isbn)
    {
        Libro? respuesta = _unitOfWork.Libros.GetDetailsById(isbn);
        if (respuesta == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<LibroDetalladoDto>(respuesta));
    }

    [HttpPut]
    public IActionResult Update(LibroDto libroDto)
    {
        if (ModelState.IsValid)
        {
            Libro libroActualizado = _unitOfWork.Libros.Update(_mapper.Map<Libro>(libroDto));
            _unitOfWork.Complete(); // save the changes to the database

            return Ok(_mapper.Map<LibroDto>(libroActualizado));
        }

        return BadRequest();
    }

    [HttpDelete("{isbn}")]
    public IActionResult Delete(string isbn)
    {
        if (_unitOfWork.Libros.Delete(isbn))
        {
            _unitOfWork.Complete();
            return Ok();
        }

        return UnprocessableEntity();
    }

    [HttpGet("filtros")]
    public IActionResult Filter([FromQuery] int? autorId, [FromQuery] string? genero, [FromQuery] int? precioInf,
        [FromQuery] int? precioSup)
    {
        var filters = new List<Expression<Func<Libro, bool>>>();

        if (autorId != null)
        {
            filters.Add(l => l.AutorId == autorId);
        }

        if (genero != null)
        {
            filters.Add(l => l.Genero == genero);
        }

        if (precioInf != null)
        {
            filters.Add(l => l.Precio >= precioInf);
        }
        
        if (precioSup != null)
        {
            filters.Add(l => l.Precio <= precioSup);
        }

        return Ok(_mapper.Map<IEnumerable<LibroDetalladoDto>>(_unitOfWork.Libros.GetAll(filters, includeProperties:"Autor")));
    }
}