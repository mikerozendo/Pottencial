using Pottencial.Application.Utils;
using Pottencial.Test.Pottencial.Application.Test.Utils;

namespace Pottencial.Test.Pottencial.Application.Test;

public class PaginadorTeste
{
    [Fact]
    public void TestaQuantidadePaginas()
    {
        //Arrange
        var list = new PaginadorHelper().ObterMock();
        var paginador = new Paginador<string>();

        //Act
        int paginas = paginador.ObterQuantidadePaginas(list);

        //Assert
        Assert.Equal(3, paginas);
    }

    [Fact]
    public void TestaQuantidadePaginas_Colecao_Zerada()
    {
        //Arrange
        var paginador = new Paginador<string>();

        //Act
        int paginas = paginador.ObterQuantidadePaginas(new List<string>());

        //Assert
        Assert.Equal(1, paginas);
    }

    [Fact]
    public void TestaQuantidadePaginas_Menor()
    {
        //Arrange
        var paginador = new Paginador<string>();
        var list = new PaginadorHelper().ObterMockMenor50();

        //Act
        int paginas = paginador.ObterQuantidadePaginas(list);

        //Assert
        Assert.Equal(1, paginas);
    }
}
