/// <summary>
/// Clase numerica de CommandType
/// </summary>
public enum CommandType
{
    Cancel = 1,
    Delete = 2,
    Edit = 3,
    Insert = 4,
    New = 5,
    Select = 6,
    Update = 7
}

/// <summary>
/// Clase numérica de ButtonCmdType
/// </summary>
public enum ButtonCmdType
{
    Button = 1,
    Image = 2,
    Link = 3
}

/// <summary>
/// Clase numérica de ShowButtonBase
/// </summary>
public enum ShowButtonBase
{
    None = 0,
    Cancel = 1,
    Delete = 2,
    Edit = 3,
    Insert = 4,
    Select = 5
}

/// <summary>
/// Clase numérica de BoundFieldType
/// </summary>
public enum BoundFieldType
{
    Integer = 1,
    Decimal = 2,
    Varchar = 3,
    DateTime = 4
}

/// <summary>
/// Clase numérica de GridViewColumnType
/// </summary>
public enum GridViewColumnType
{
    BoundField = 1,
    CommandField = 2,
    CheckField = 3,
    TemplateField = 4
}
