namespace nGratis.Cop.Core.Testing
{
    using nGratis.Cop.Core.Contract;

    public class CopTheory<TParameter> : CopTheory
    {
        public CopTheory(TParameter parameter)
        {
            Guard
                .Require(parameter, nameof(parameter))
                .Is.Not.Default();

            this.Parameter = parameter;
        }

        public TParameter Parameter { get; }
    }

    public class CopTheory
    {
        public string Label { get; private set; }

        public static CopTheory<TParameter> Create<TParameter>(TParameter parameter)
        {
            return new CopTheory<TParameter>(parameter);
        }

        public CopTheory WithLabel(string label)
        {
            Guard
                .Require(label, nameof(label))
                .Is.Not.Empty();

            this.Label = label;

            return this;
        }

        public object[] ToXunitTheory()
        {
            return new object[] { this };
        }

        public override string ToString() => !string.IsNullOrEmpty(this.Label)
            ? $"[ {this.Label} ]"
            : base.ToString();
    }
}