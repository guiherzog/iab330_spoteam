using MvvmCross.Plugins.Messenger;

public class NFCMessage
  : MvxMessage
{
	public NFCMessage(object sender, string _id)
	  : base(sender)
	{
		ID = _id;
	}

	public string ID { get; private set; }
}