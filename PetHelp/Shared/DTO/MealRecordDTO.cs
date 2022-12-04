namespace PetHelp.Shared.DTO;

public class MealRecordDTO
{
    private string? _name = null;
    private int? _weight = null;
    private DateTime? _date = null;

    public MealRecordDTO()
    {

    }
    public MealRecordDTO(States state)
    {
        CurrentState = state;
    }

    public int Id 
    { 
        get; init; 
    }
    public DateTime Date 
    { 
        get => _date ?? default; 
        set 
        { 
            if (_date.HasValue && _date.Value != value && CurrentState == States.None)
            {
                CurrentState = States.Updated;
                Console.WriteLine($"{nameof(Date)} changed, set state to {States.Updated}");
            }
            _date = value;
        }  
    }
    public int Weight 
    { 
        get => _weight ?? 0; 
        set 
        {
            if (_weight.HasValue && _weight.Value != value && CurrentState == States.None)
            {
                CurrentState = States.Updated;
                Console.WriteLine($"{nameof(Weight)} changed, set state to {States.Updated}");
            }
            _weight = value;
        }
    }
    public string Name 
    {
        get => _name ?? string.Empty; 
        set 
        {
            if (_name != null && _name != value && CurrentState == States.None)
            {
                CurrentState = States.Updated;
                Console.WriteLine($"{nameof(Name)} changed, set state to {States.Updated}");
            }
            _name = value;
        } 
    }
    public int Type 
    { 
        get; init; 
    }
    public int PetId 
    { 
        get; init; 
    }
    public States CurrentState 
    { 
        get; private set; 
    }

    public void SetState(States state)
    {
        CurrentState = state;
    }

    public enum States
    {
        None,
        Added,
        Updated,
        Deleted
    }
}
