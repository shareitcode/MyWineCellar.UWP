using FluentValidation;
using MyWineCellar.Models;

namespace MyWineCellar.Validators
{
	internal abstract class ValidatorBase<Model> : AbstractValidator<ModelBase> where Model : ModelBase { }
}