## Installation

Before getting started, ensure that you have .NET SDK 7 installed.

To verify if you have the SDK 7 installed, run the following command in your terminal:

```
dotnet --version
```

## Quick Start

1. Clone this repository to your local machine:

```
git clone https://github.com/IDWM/courses-dotnet-api.git
```

2. Navigate to the project folder:

```
cd course-api-project
```

3. Restore the project dependencies:

```
dotnet restore
```

4. Create a migration:

```
dotnet ef migrations add InitialCreate
```

5. Run the project

```
dotnet run
```