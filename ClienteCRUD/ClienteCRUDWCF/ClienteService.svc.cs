using ClienteCRUDLogica;
using ClienteCRUDModel;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.ServiceModel;

namespace ClienteCRUDWCF
{
    public class ClienteService : DIService, IClienteService, ISexoService, IEstadoCivilService, IOrgaoExpedicaoService, IEnderecoService
    {
        #region Cliente

        public ClienteModel SaveCliente(ClienteModel cliente)
        {
            try
            {
                return clienteLogica.Save(cliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public ClienteModel AtualizarCliente(string idCliente, ClienteModel cliente)
        {
            try
            {
                return clienteLogica.Save(idCliente, cliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public void DeleteCliente(string idCliente)
        {
            try
            {
                clienteLogica.Delete(idCliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public IEnumerable<ClienteModel> GetAllCliente(int pagina)
        {
            try
            {
                return clienteLogica.GetAll(pagina);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        public ClienteModel GetCliente(string idCliente)
        {
            try
            {
                return clienteLogica.Get(idCliente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

        #region EstadoCivil

        public IEnumerable<EstadoCivilModel> GetAllEstadoCivil()
        {
            try
            {
                return estadoCivilLogica.GetAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        #endregion

        #region OrgaoExpedicao

        public IEnumerable<OrgaoExpedicaoModel> GetAllOrgaoExpedicao()
        {
            try
            {
                return orgaoExpedicaoLogica.GetAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

        #region Sexo
        public IEnumerable<SexoModel> GetAllSexo()
        {
            try
            {
                return sexoLogica.GetAll();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        #endregion

        #region Endereco
        public EnderecoModel GetEnderecoByCep(string cep)
        {
            try
            {
                return enderecoLogica.GetEnderecoByCep(cep);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        public EnderecoModel SaveEndereco(EnderecoModel endereco)
        {
            try
            {
                return enderecoLogica.Save(endereco);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        public EnderecoModel GetEndereco(string idEndereco)
        {
            try
            {
                return enderecoLogica.GetEndereco(idEndereco);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }            
        }

        #endregion
    }
}
