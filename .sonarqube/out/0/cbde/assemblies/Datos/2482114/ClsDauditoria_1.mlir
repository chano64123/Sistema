// Skipping function agregarAuditoria(none), it contains poisonous unsupported syntaxes

func @_Datos.ClsDauditoria.listarAuditoria$$() -> none loc("F:\\UPT\\VII CICLO\\Z JEANET\\Sistema\\Datos\\ClsDauditoria.cs" :18 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("F:\\UPT\\VII CICLO\\Z JEANET\\Sistema\\Datos\\ClsDauditoria.cs" :19 :24) // from e in db.tbAuditoria select e (QueryExpression)
%2 = cbde.unknown : none loc("F:\\UPT\\VII CICLO\\Z JEANET\\Sistema\\Datos\\ClsDauditoria.cs" :20 :19) // Not a variable of known type: query
%3 = cbde.unknown : none loc("F:\\UPT\\VII CICLO\\Z JEANET\\Sistema\\Datos\\ClsDauditoria.cs" :20 :19) // query.ToList() (InvocationExpression)
return %3 : none loc("F:\\UPT\\VII CICLO\\Z JEANET\\Sistema\\Datos\\ClsDauditoria.cs" :20 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function filtrarAuditoria(none), it contains poisonous unsupported syntaxes

