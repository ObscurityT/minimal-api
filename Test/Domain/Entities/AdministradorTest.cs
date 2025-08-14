using Microsoft.VisualStudio.TestTools.UnitTesting;
using minimalApi.Dominio.Entities;

namespace Test.Domain.Entities;

[TestClass]
public sealed class AdministradorTest
{
    [TestMethod]
    public void TestGetSetProperties()
    {
        //arrange
        var adm = new Administrador();

        //act
        adm.Id = 1;
        adm.Email = "teste@test.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        //assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@test.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
        
    }
}
