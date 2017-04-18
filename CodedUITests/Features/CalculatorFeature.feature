Feature: CalculatorFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <number_1> into the calculator
	And I press add
	And I have entered <number_2> into the calculator
	When I press equals
	Then the result should be <result> on the screen

	Examples: 
	| number_1 | number_2 | result |
	| 1        | 2        | 3      |
	| 10       | 20       | 30     |
	| 50       | 35       | 85     |
	| 24567    | 12345    | 36912  |