# Task

https://test.vmarmysh.com/user/description/backend

# Questions

1. Why the API does not use a common slash-separated resource notation?
2. Why the API does not follow HTTP standard? Why does it not use GET, PUT, DELETE? Why are query parameters used in a wrong way?
3. Why are the names of the types so unreadable? (FxNet.Web.Model.MRange<FxNet.Web.Def.Api.Diagnostic.Model.MJournalInfo>)
4. FxNet.Web.Def.Api.Diagnostic.View.VJournalFilter - why is search marked as required when it actually is optional?
5. Why there are no error status codes defined in the contract?
6. Why do deletion and modification commands return 200 with empty bodies?
7. Why does /api.user.tree.get creates the tree if it does not exist? Is it a query or a command?
8. ReactTest.Tree.Site.Model.MNode - why is the contract of children is undefined?
9. According to the examples ReactTest.Tree.Site.Model.MNode.children may contain null items. Why and how is this possible?
10. "The database model has to be designed" - why should we design the database model instead of the domain model?
11. "The journal of all exceptions" - seems like it is not a part of the domain. Should we not use more appropriate tools for monitoring, such as log or trace aggregators?
12. "Your application should provide Rest API similar (ideally the same) to the existing (check swagger)." - this is not a Rest API, it does not follow the Rest principles.
13. "You have to delete all children nodes first" - this seems to be a validation error, so it's more like 400 instead of 500, more like ValidationException instead of SecureException and more like a user error instead of exception.
14. Since neither the domain rules nor the contract of errors is defined, it is hard to tell which cases should lead to exceptions and which exceptions should be considered "secure".
15. Since there is no glossary defined it is hard to understand whether the node or the tree should be considered as an aggregate root. Both solutions would have its own advantages and disadvantages. Here is the "node-as-aggregate" implementation.
16. The task requires "2-3 hours". Since it is impossible to write a good maintainable and well-tested code in 2-3 hours, unit tests are missing and the code quality is doubtable.
