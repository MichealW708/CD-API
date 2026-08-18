# C# CI/CD Demo

A resume-ready ASP.NET Core Web API demonstrating a production-style CI/CD workflow with automated builds, tests, code coverage, formatting validation, dependency vulnerability checks, security analysis, and merge-gate design using GitHub Actions.

## Skills demonstrated

- C# / ASP.NET Core REST API development
- Unit testing with xUnit
- Integration testing with WebApplicationFactory
- GitHub Actions CI/CD
- Automated build validation
- Code coverage collection
- Formatting validation
- NuGet dependency vulnerability auditing
- GitHub CodeQL security analysis
- Pull-request quality gates
- Branch-protection strategy

## Pipeline

```text
Pull Request
     |
     v
GitHub Actions
     |
     +--> Restore
     +--> Build
     +--> Unit / integration tests
     +--> Coverage collection
     +--> Formatting validation
     +--> Vulnerability audit
     +--> CodeQL security analysis
     |
     v
All required checks pass?
     |
   +---+---+
   |       |
  No      Yes
   |       |
Block    Merge
merge
```

## API endpoints

- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`

Example POST body:

```json
{
  "name": "Mechanical Keyboard",
  "price": 129.99
}
```

## Run locally

Requires the .NET 8 SDK.

```bash
dotnet restore tests/Api.Tests/Api.Tests.csproj
dotnet build tests/Api.Tests/Api.Tests.csproj
dotnet test tests/Api.Tests/Api.Tests.csproj
dotnet run --project src/Api
```

## CI/CD merge gates

The `CI` workflow validates every pull request targeting `main`. It fails when the project cannot build, tests fail, formatting differs, or the dependency audit command fails. The separate `Security` workflow runs CodeQL analysis.

To make these true merge gates, configure a GitHub ruleset or branch protection rule for `main` and require the workflow status checks before merging.

Recommended settings:

- Require a pull request before merging
- Require at least one approval
- Require status checks to pass
- Require branches to be up to date
- Require conversation resolution
- Block force pushes
- Block deletion of `main`

## Why this project is resume-friendly

The project demonstrates more than writing an API. It shows how engineering teams protect the main branch using repeatable automated validation. The key design concept is that CI checks should be deterministic and trustworthy enough to become required checks rather than advisory checks.

## Resume bullet

**C# CI/CD Demo — GitHub Actions** — Designed and implemented an ASP.NET Core REST API with automated GitHub Actions quality gates for builds, unit/integration testing, code coverage, formatting validation, dependency vulnerability auditing, and CodeQL security analysis; designed branch-protection requirements to prevent failing pull requests from merging.

## Interview talking points

**What happens when a test fails?**  
`dotnet test` exits unsuccessfully, the CI job fails, and—when that job is configured as a required status check—GitHub blocks the pull request from merging.

**Why are reliable checks important?**  
A flaky or overly broad test makes a poor merge gate because it can block healthy changes. Merge-blocking checks should be deterministic, fast enough for pull-request feedback, and focused on conditions that truly make a change unsafe.

**Why separate security analysis?**  
Security scanning has different permissions and maintenance needs from ordinary build/test validation. A separate workflow makes those responsibilities easier to understand and evolve.

**What would you add for a production deployment pipeline?**  
Container builds, image scanning, a staging environment, infrastructure as code, deployment approvals, secrets management, smoke tests, observability, and rollback automation.

## Suggested GitHub repository description

`ASP.NET Core API showcasing CI/CD merge gates, automated tests, CodeQL security analysis, dependency auditing, and branch protection with GitHub Actions.`
