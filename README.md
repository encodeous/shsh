# shShortener - Lightweight Link Shortener

A random project I decided to create on a free afternoon! Live Demo: https://shsh.ml/

## Tech Used

- ASP.NET Core + Blazor for frontend and API
- EF Core + SQLite for database
- Nginx w/ Reverse Proxy

## How it works

A random code is generated that consists of Upper/Lowercase and Numerical characters, or the user can choose their own code.

The code is used as a key in the Database to enable mapping.

When the API is called, the Database is queried and the client is redirected with a 301 redirect.
