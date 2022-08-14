using FluentValidation;

namespace GuestBook.Validators
{
    public class AuthValiadtor : AbstractValidator<Models.User.User>
    {
        public AuthValiadtor() {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            // TODO: Add other password validation techniques
            RuleFor(x => x.Password).Length(8, 20);
        }
    }
}
