## Introduktion
Projektet syftade till att utveckla en robust backendlösning för hantering av kund- och bokningsinformation. Detta inkluderade möjligheten att spåra ändringar i bokningar, filtrering och sortering av data samt säkerhetshantering för att skydda kundinformation. Implementeringen genomfördes med hjälp av .NET-teknologier med fokus på att leverera en skalbar, säker och effektiv lösning. Denna beskrivning syftar till att belysa de tekniska val och arkitekturstrategier som användes under projektet, med särskilt fokus på de självständiga bedömningarna och analyserna som ledde till mycket goda resultat.

## Val av Tekniska Metoder
Entity Framework Core
Entity Framework Core (EF Core) valdes som Object-Relational Mapper (ORM) för att hantera datalagring och -återhämtning. Detta val baserades på EF Cores förmåga att förenkla databasinteraktioner genom LINQ-frågor och automatisk hantering av migrations. EF Core möjliggör också stöd för komplexa relationer och avancerade funktioner som spårning av entiteter och hantering av kaskadborttagningar. Denna flexibilitet och kraftfulla funktionalitet gjorde EF Core till ett välavvägt val för att säkerställa en effektiv och hanterbar databasstruktur.

## ASP.NET Core Web API
För att exponera funktionaliteten som RESTful API:er valdes ASP.NET Core Web API. Detta ramverk erbjuder hög prestanda och låg latens, vilket är avgörande för att tillhandahålla en responsiv och skalbar backendlösning. ASP.NET Core Web API stöder också enkla konfigurationsmöjligheter för autentisering och auktorisering, vilket var nödvändigt för att skydda kunddata. Användningen av detta ramverk gjorde det möjligt att bygga en robust och säker tjänst med stöd för beroendeinjektion och konfigurerbara middleware-komponenter.
