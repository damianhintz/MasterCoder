namespace Parser
{
    public abstract class IParserListener
    {
        public abstract void newVCard(vCardStruct vCard);
    }
}