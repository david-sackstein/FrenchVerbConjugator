# FrenchVerbConjugator

The objective of this project is to determine the minimum set of rules that together conjugate all verbs in the French Language.
It uses the [french-verbs-lefff](https://www.npmjs.com/package/french-verbs-lefff) project as the database for the conjugations of over 7000 verbs.

## Conjugation data

The reference conjugation data comes from the [french-verbs-lefff](https://www.npmjs.com/package/french-verbs-lefff) npm package (version 0.10.1), which is based on the [LEFFF lexicon](http://alpage.inria.fr/~sagot/lefff.html) (Lexique des Formes Fléchies du Français).

The two JSON files the tests depend on are committed directly to this repo under `node_modules/french-verbs-lefff/dist/` so no Node.js installation is required. If those files are ever lost, restore them with:

```bash
git restore node_modules/
```

Or re-download the package manually:

```bash
npm install french-verbs-lefff@0.10.1
```

The project is implemented with TDD as follows: 

- Select a verb and its conjugations from the database
- Conjugate using the library
- If it fails, add the rule or rules that make it pass

