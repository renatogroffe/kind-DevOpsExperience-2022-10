using APISuporte.Data;
using APISuporte.Models;

namespace APISuporte.Services;

public class ChamadosService
{
    private readonly ChamadosRepository _repository;

    public ChamadosService(ChamadosRepository repository)
    {
        _repository = repository;
    }

    public DetalhesChamado? Get(string idChamado)
    {
        var document = _repository.Get(idChamado);
        if (document is not null)
            return new DetalhesChamado()
            {
                Id = document._id.ToString(),
                DataChamado = document.DataAbertura,
                Email = document.Email,
                DescritivoRequisicao = document.DescritivoRequisicao,
                Solucionado = document.Solucionado
            };
        return null;
    }

    public ResultadoInclusao Save(RequisicaoSuporte requisicaoSuporte)
    {
        var chamado = new ChamadoDocument()
        {
            DataAbertura = DateTime.UtcNow.AddHours(-3).ToString("dd/MM/yyyy HH:mm:ss"),
            Email = requisicaoSuporte.Email,
            DescritivoRequisicao = requisicaoSuporte.Email, // FIXME: Simulacao de falha
            //DescritivoRequisicao = requisicaoSuporte.DescritivoRequisicao,
            Solucionado = true // FIXME: Simulacao de falha
            //Solucionado = false            
        };
        var idChamadoSuporte = _repository.Save(chamado);

        return new ResultadoInclusao()
        {
            IdChamado = idChamadoSuporte,
            Mensagem = "Chamado registrado com sucesso!"
        };
    }
}