public class Thing
{
	public Thing(string label, string value)
	{
		Label = label;
		Value = value;
	}

	public string Value { get; private set; }
	public string Label { get; private set; }

	public override string ToString()
	{
		return Value;
	}

	public override bool Equals(object obj)
	{
		var rhs = obj as Thing;
		if (rhs == null)
			return false;
		return rhs.Value == Value;
	}

	public override int GetHashCode()
	{
		if (Value == null)
			return 0;
		return Value.GetHashCode();
	}
}	