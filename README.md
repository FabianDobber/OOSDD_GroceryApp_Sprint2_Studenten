# Grocery App

Deze repository bevat de **Grocery App**. De ontwikkeling volgt een vereenvoudigde Gitflow-structuur.

---

## Branch-strategie

- **main**  
  Bevat altijd stabiele, productieklare code. Nieuwe versies komen hier via Pull Request van `develop`.

- **develop**  
  Integratiebranch waar alle features samenkomen. Alle ontwikkeling gebeurt hier uiteindelijk.

- **feature/***  
  Voor nieuwe features of use cases.  
  Voorbeelden: `feature/UC4`, `feature/UC5`, `feature/UC6-login`.

- **docs/***  
  Voor documentatie-aanpassingen zoals README of CONTRIBUTING.md.  
  Voorbeeld: `docs/update-readme`.

- **hotfix/***  
  Voor urgente fixes in productie. Wordt terug gemerged naar zowel `main` als `develop`.

---

## Workflow

### Nieuwe feature
1. Checkout `develop` en pull de laatste versie:
```bash
git checkout develop
git pull
git checkout -b feature/UCx
```
* Ontwikkel de feature en commit regelmatig.

* Push de branch en open een Pull Request naar develop.

* Laat review uitvoeren en merge na goedkeuring.

### Documentatie-aanpassingen
Checkout develop:

```bash
	git checkout develop
	git pull
	git checkout -b docs/update-readme
```
* Pas documentatie aan, commit en push.
* Open een Pull Request naar develop en merge na review.

### Release naar productie

* Open een Pull Request van develop naar main.

* Voeg een duidelijke releasebeschrijving toe met de belangrijkste features, fixes en eventuele breaking changes.

* Merge na succesvolle tests en review.


Tag de release (bijv. v1.0.0) en push de tag:

```bash
git tag v1.0.0
git push --tags
```
### Richtlijnen

* Nooit directe commits op main of develop.

* Gebruik duidelijke branch-namen (feature/*, docs/*, hotfix/*).

* Commit messages volgen het patroon: feat(scope), fix(scope), docs(scope).

* Verwijder gemergde branches om overzicht te behouden.
