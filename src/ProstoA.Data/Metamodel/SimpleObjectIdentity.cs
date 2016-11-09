namespace ProstoA.Data.Metamodel {
    public class SimpleObjectIdentity : IObjectIdentity {
        public SimpleObjectIdentity(string name) {
            Key = name;
        }

        public IObjectClass Class => null;

        public string Key { get; }

        public SemanticVersion Version => null;
    }
}