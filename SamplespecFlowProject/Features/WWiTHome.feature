Feature: WWiTHome

this feature will navigate to the WWiT home page and validate the content 

@tag1
Scenario: Navigate to the WWiT Home Page 
	Given I navigate to the "https://wwit.netlify.app"
	Then I expect to see the "<message>"
