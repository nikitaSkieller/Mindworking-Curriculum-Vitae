# Mindworking Curriculum Vitae

This is a web service that can give you a curriculum vitae (CV). 
The CV includes information about education, work experience, skills, projects, and contact information.

Via GraphQL, you can query for specific information in the CV, such as education history or work experience.

## Techstack
•	Language and runtime: C# 12, .NET 8
•	Web framework: ASP.NET Core minimal hosting
•	GraphQL server: Hot Chocolate (AddGraphQLServer, filtering, sorting, paging)
•	Data access: Entity Framework Core
•	Database: SQLite (Data Source=cv.db)
•	Project type: SDK-style .NET project
•	Testing: xUnit with snapshot-style tests
•	Repository: Git (GitHub)

## Data
The database is seeded automatically when started.

## Testing


## Run
Run in visual studio or via command line with `dotnet run` in the project directory. The GraphQL endpoint will be available at `http://localhost:[port]/graphql` and you will be redirected directly.

## Example queries
In these examples paging and filtering are not used due to the small amount of data seeded at this point.

### Companies
Query companies sorted by start date in descending order:

query {
  companies(
    order: [
      { startDate: DESC }
    ])
    {
      nodes{
        name
        summary
        title
        startDate
        endDate
        projects{
          nodes{
            name
            summary
          }
        }
      }
    }
}

Query company by Id:

query {
  companyById(id: 1){
    name
    summary
    startDate
    endDate
    projects{
      nodes{
        name
        summary
      }
    }
  }
}

### Educations
Query educations by end date in descending order:

query{
  educations(order: [ {
     endDate: DESC
  }]){
    nodes{
      school
      degree
      startDate
      endDate
    }
  }
}

Query education by id:
query{
  educationById(id: 1) {
    school
    degree
    startDate
    endDate
  }
}

### Projects
Query all projects:
query{
  projects{
    nodes{
      name
      summary
      company{
        name
      }
    }
  }
}

Query project by Id:
query{
  projectById(id: 1) {
    name
    summary
    company{
      name
    }
  }
}

### Skills
Query all skills:
query{

  skills{
    nodes{
      name
      description
      level
    }
  }
}

Query a skill by id:
query{
  skillById(id: 1){
    name
    description
    level
  }
}



