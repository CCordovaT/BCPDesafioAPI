using System;
using BCP.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCP.Repositories.Tests
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private readonly ClienteRepository clienteRepository;

        public ClienteRepositoryTests()
        {
            clienteRepository = new ClienteRepositoryImp();
        }

        [TestMethod]
        public void DeberiaInsertarUnCliente()
        {
            var nuevoCliente = new Cliente()
            {
                IdTipoDocumento = 1,
                NroDocumento = "87654321",
                Nombres = "TEST",
                PrimerApellido = "SEGUNDO",
                SegundoApellido = "CLIENTE",
                NroCelular = "111111112"
            };

            var idNuevoCliente = clienteRepository.Insert(nuevoCliente);

            idNuevoCliente.Should().NotBe(0);
        }
    }
}
