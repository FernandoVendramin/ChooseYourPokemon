Feature: MainPageRequirements
	Validate pokemon selection

Background: 
	Given a started app

@mainpage
Scenario: An user selected Charmander
	Given an user at main page screen
	When he press button choose pokemon
	And he selected charmander pokemon
	Then show charmander selected