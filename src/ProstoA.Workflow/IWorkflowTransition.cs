using System.Collections.Generic;

using ProstoA.Data.Metamodel;

namespace ProstoA.Workflow {
    public interface IWorkflowTransition {
        IObjectIdentity Name { get; }

        IObjectDisplay Display { get; }

        IDataObject Data { get; }

        IEnumerable<IWorkflowState> NextStates { get; }
    }
}