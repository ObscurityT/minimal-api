using Microsoft.EntityFrameworkCore;
using minimalApi.Dominio.Entities;
    using minimalApi.Dominio.Interfaces;
    using minimalApi.DTOs;
using minimalApi.Infraestrutura.Db;

namespace minimalApi.Dominio.Service;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.administradores.AsQueryable();

        int itensPorPagina = 10;

        if (pagina != null)
        {
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }

        return query.ToList();
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.administradores.Where(v => v.Id == id).FirstOrDefault();
    }
}