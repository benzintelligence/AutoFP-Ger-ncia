using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Entities.Order;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Entities.Veiculo;
using AutoFP.Gerencia.Infra.Data.Mappings;
using AutoFP.Gerencia.Infra.Data.Mappings.Localizacao;
using AutoFP.Gerencia.Infra.Data.Mappings.Order;
using AutoFP.Gerencia.Infra.Data.Mappings.Pessoa;
using AutoFP.Gerencia.Infra.Data.Mappings.Produto;
using AutoFP.Gerencia.Infra.Data.Mappings.Veiculo;

namespace AutoFP.Gerencia.Infra.Data.Context
{
    public class AutoFpContext : DbContext
    {
        public AutoFpContext() : base("AutoFpContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new CreateDatabaseIfNotExists<AutoFpContext>());
        }

        #region DBSet's
        public DbSet<AnoModeloCarro> AnoModeloCarros { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<CategoriaPeca> CategoriaPecas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<PosicaoPeca> PosicaoPecas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AnoModeloCarroMap());
            modelBuilder.Configurations.Add(new CarroMap());
            modelBuilder.Configurations.Add(new CategoriaPecaMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new EmailMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new GaleriaMap());
            modelBuilder.Configurations.Add(new ItemPedidoMap());
            modelBuilder.Configurations.Add(new MarcaMap());
            modelBuilder.Configurations.Add(new MontadoraMap());
            modelBuilder.Configurations.Add(new PecaMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaJuridicaMap());
            modelBuilder.Configurations.Add(new PessoaFisicaMap());
            modelBuilder.Configurations.Add(new PosicaoPecaMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataRegistro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataRegistro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataRegistro").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCompra") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCompra").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCompra").IsModified = false;
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}