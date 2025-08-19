using minimal_api.Dominio.Enuns;

namespace minimal_api.Dominio.ModelViews;

public record AdministrdorModelView
{
    public int Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
}