namespace Blind_75.Graph;

public class CourseSchedule : ISolution
{
    public void Solve()
    {
        var res = CanFinish(2, new[] {new[]{0, 1}, new[]{1, 0}});
    }
    
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        Dictionary<int, HashSet<int>> bounds = new Dictionary<int, HashSet<int>>(numCourses);

        foreach (var bound in prerequisites)
        {
            if (!bounds.ContainsKey(bound[0]))
            {
                bounds[bound[0]] = new HashSet<int>();
            }

            bounds[bound[0]].Add(bound[1]);
        }

        foreach (var course in Enumerable.Range(0, numCourses))
        {
            if (!Search(new bool[numCourses], course, bounds))
                return false;
        }

        return true;
    }

    public bool Search(bool[] visited, int course, Dictionary<int, HashSet<int>> bounds)
    {
        if (visited[course])
            return false;

        if (!bounds.ContainsKey(course) || bounds[course].Count == 0)
            return true;

        visited[course] = true;

        foreach (var bound in bounds[course])
        {
            if (!Search(visited, bound, bounds))
                return false;
        }
        
        bounds[course].Clear();
        visited[course] = false;

        return true;
    }
}