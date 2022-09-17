using System;
using BCP.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCP.Repositories.Tests
{
    [TestClass]
    public class AgenciaRepositoryTests
    {
        private readonly BaseRepository<Agencia> agenciaRepository;

        public AgenciaRepositoryTests()
        {
            agenciaRepository = new BaseRepositoryImp<Agencia>();
        }

        [TestMethod]
        public void DeberiaDevolverTodasLasAgencias()
        {
            var nroAgenciasEsperada = 2;

            var listaAgencias = agenciaRepository.GetAll();

            listaAgencias.Should().HaveCount(nroAgenciasEsperada);
        }
    }
}
