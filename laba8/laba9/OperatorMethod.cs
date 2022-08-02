namespace laba8.laba9
{
    public class OperatorMethod
    {
        public delegate void EmptyOperatorMethod();
        public delegate void UnaryOperatorMethod(object operand);
        public delegate void BinaryOperatorMethod(object operand1, object operand2);
        public delegate void TrinaryOperatorMethod(object operand1, object operand2, object operand3);
        public delegate void SevenaryOperatorMethod(object operand1, object operand2, object operand3, object operand4, object operand5, object operand6, object operand7);
    }
}
