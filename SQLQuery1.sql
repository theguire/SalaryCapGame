SELECT Players.Id, Franchises.Id
from
	Players, Franchises, PlayerAssignments
where 
	Franchises.Id = PlayerAssignments.FranchiseId
and
	Players.Id = PlayerAssignments.PlayerId
