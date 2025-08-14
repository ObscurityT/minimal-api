using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using minimalApi.Dominio.Service;
using minimalApi.Dominio.Entities;
using minimalApi.Infraestrutura.Db;
using System.Reflection;

namespace Test.Domain.Entities;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
         
        var builder = new ConfigurationBuilder()
           .SetBasePath(path ??  Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        var context = CriarContextoDeTeste();
         context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        // arrange
        var adm = new Administrador();
        adm.Email = "teste@test.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);


        // assert

        Assert.AreEqual(1, admDoBanco.Id);
        
    }
}
