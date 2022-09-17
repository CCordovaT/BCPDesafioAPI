using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCP.Repositories.Tests
{
    [TestClass]
    public class UsuarioRepositoryTests
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioRepositoryTests()
        {
            usuarioRepository = new UsuarioRepositoryImp();
        }

        [TestMethod]
        public void DeberiaDevolverUsuarioPorCodAcceso()
        {
            var usuarioEsperado = usuarioRepository.GetAll()[0];

            var usuarioActual = usuarioRepository.ObtenerPorCodAcceso(usuarioEsperado.CodAccesoUsuario);

            usuarioActual.Should().BeEquivalentTo(usuarioEsperado, options => options.Excluding(p => p.DescripcionCargo)
                                                                                     .Excluding(p => p.NombreAgencia));
            usuarioActual.DescripcionCargo.Should().NotBeNullOrEmpty();
            usuarioActual.NombreAgencia.Should().NotBeNullOrEmpty();
        }
    }
}
