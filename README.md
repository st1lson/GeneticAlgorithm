# GeneticAlgorithm
## Algorithm information

An algorithm based on biologically inspired operators such as mutation, crossover and selection.
<br /> [Wikipedia article](https://en.wikipedia.org/wiki/Genetic_algorithm) about Genetic algorithm.

## config.json example
Here we can easily and quickly configure algorithm limitations.

``` json
{
  "Path": "default.txt",
  "IterationsCount": 1000,
  "Separators": [
    "with weight",
    "and cost"
  ],
  "PossibleItems": [
    "Item names..."
  ],
  "MaxWeight": 500,
  "ItemsCount": 100,
  "MinItemCost": 2,
  "MaxItemCost": 30,
  "MinItemWeight": 1,
  "MaxItemWeight": 20,
  "PopulationCount": 100,
  "EvolutionChance": 0.05,
  "CrossingoverChance": 0.5
}
```

## Source file example
The first line stands for items count. For example use `100`.
<br />Then follows enumeration of the items in the following format `Item with weight x and cost y` where `x` and `y` integers.

```
100
Item with weight x and cost y
Laptop with weight 5 and cost 25
...
```
