Example of ASP.net core 2.1 API using dependency injection for reading configuration from appsettings.json into POCO classes.

I got most of this from [StackOverflow][1].

## Integration Tests
I referred to [Microsoft's][2] documentation as well as [an article from Mark Macneil][3] on setting up integration test using the *Microsoft.AspNetCore.Mvc.Testing* package.

Along the way, I ran into an issue trying to run the integration test, with the following error:

```
FileNotFoundException: Could not load file or assembly 'Microsoft.AspNetCore, Version=2.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'. The system cannot find the file specified.
```

This was resolved using the method described in this StackOverflow [article][4].


[1]: https://stackoverflow.com/questions/46940710/getting-value-from-appsettings-json-in-net-core
[2]: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.1
[3]: https://fullstackmark.com/post/20/painless-integration-testing-with-aspnet-core-web-api
[4]: https://stackoverflow.com/questions/50401152/integration-and-unit-tests-no-longer-work-on-asp-net-core-2-1-failing-to-find-as