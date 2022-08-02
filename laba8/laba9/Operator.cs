namespace laba8.laba9
{
    public class Operator : OperatorMethod
    {
        public char symbolOperator;
        public EmptyOperatorMethod operatorMethod = null;
        public BinaryOperatorMethod binaryOperator = null;
        public TrinaryOperatorMethod trinaryOperator = null;
        public SevenaryOperatorMethod sevenaryOperator = null;

        public Operator(EmptyOperatorMethod operatorMethod, char symbolOperator)
        {
            this.operatorMethod = operatorMethod;
            this.symbolOperator = symbolOperator;
        }
        public Operator(BinaryOperatorMethod binaryOperator, char symbolOperator)
        {
            this.binaryOperator = binaryOperator;
            this.symbolOperator = symbolOperator;
        }
        public Operator(TrinaryOperatorMethod trinaryOperator, char symbolOperator)
        {
            this.trinaryOperator = trinaryOperator;
            this.symbolOperator = symbolOperator;
        }
        public Operator(SevenaryOperatorMethod sevenaryOperator, char symbolOperator)
        {
            this.sevenaryOperator = sevenaryOperator;
            this.symbolOperator = symbolOperator;
        }
        public Operator(char symbolOperator)
        {
            this.symbolOperator = symbolOperator;
        }
    }
}
