using FluentValidation;
using APISuporte.Models;

namespace APISuporte.Validations;

public class RequisicaoSuporteValidator : AbstractValidator<RequisicaoSuporte>
{
    public RequisicaoSuporteValidator()
    {
        RuleFor(r => r.Email).NotEmpty().WithMessage("Preencha o campo 'Email'")
            .EmailAddress().WithMessage("Formato invalido para o campo 'Email'")
            .MaximumLength(100).WithMessage("O campo 'Email' deve possuir no maximo 100 caracteres");

        RuleFor(r => r.DescritivoRequisicao).NotEmpty().WithMessage("Preencha o campo 'DescritivoRequisicao'")
            .MinimumLength(15).WithMessage("O campo 'DescritivoRequisicao' deve possuir no minimo 15 caracteres")
            .MaximumLength(500).WithMessage("O campo 'DescritivoRequisicao' deve possuir no maximo 500 caracteres");
    }
}