using Microsoft.EntityFrameworkCore;
using Minimal.Infraestrutura.Db;
using minimal_api.Dominio.Entidades;


namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest
{
  /*   private DbContexto CriarContextoDeTeste()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
        .UseInMemoryDatabase(databaseName:"TesteDatabase")
        .Options;

        return new DbContexto(options);


    } */
       


    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        //arrange - todas as variáveis criadas para validações
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
        //  var context = CriarContextoDeTeste();
        var administradorServico = new AdministradorServicoTest();

        //act - ações a serem realizadas
       // administradorServico.Incluir(adm);



        //Assert - validações dos dados
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
    }
}
