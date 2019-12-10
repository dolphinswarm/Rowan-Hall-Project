using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ScavengerHuntItem : MonoBehaviour
{
    // ================================================= Variables
    // Public variables
    public GameObject text;
    public GameObject popup;
    public List<AudioClip> audio_clips;

    // Private variables
    private int current_clip = 0;
    private Renderer renderer;
    private GameObject ar_camera;
    private List<string> demands;

    // ================================================= Methods
    void Start()
    {
        // Set Renderer and AR Camera
        renderer = GetComponent<Renderer>();
        ar_camera = GameObject.FindGameObjectWithTag("MainCamera");

        // Change the position of the megaphone
        ChangePosition();

        // Hide the popup window
        popup.SetActive(false);

        // Initialize and populate the list of BAM demands
        demands = new List<string>();

        // BAM 1.0 - Demand #1
        demands.Add("Recommendations for increasing the numbers of graduate and undergraduate professional recruiters.");

        // BAM 1.0 - Demand #2
        demands.Add("A goal of 10% of the total population in Ann Arbor is made up of black students by 1973-74. This shall increase yearly until the overall population " +
            "of Blacks shall approach, if not exceed the proportion of blacks in the state. More specifically, we demand that in the academic year 1971-72, there shall be " +
            "an incoming class which includes at least 450 Black freshman and 150 transfer students, as well as 300 new Black graduate students.");

        // BAM 1.0 - Demand #3
        demands.Add("A plan of supportive services was designed to make the increase of risk students feasible.");

        // BAM 1.0 - Demand #4
        demands.Add("All work on the Black Studies Program is halted until a community/University input can be fully developed to ensure the desire of the people.");

        // BAM 1.0 - Demand #5
        demands.Add("The establishment of a community located Black Studies Center is demanded.");

        // BAM 1.0 - Demand #6
        demands.Add("The Martin Luther King Scholarship Fund is to be revitalized. The Parents is to be established for those who contend to be short of finances.");

        // BAM 1.0 - Demand #7
        demands.Add("Finally we demand that tuition waivers be granted to financially disadvantaged students admitted under special programs. " +
            "The process of describing a tuition for students to have their tuition waived, a mechanism which is largely different from that of the scholarship. " +
            "A summary of the legal precedent is attached. Notably the arguments forwarded at the U of M can be made at any state university. ");

        // BAM 2.0 - Demand #1
        demands.Add("We demand that Miami University identifies space on campus for the construction of a new building to serve as the Center for Student Inclusion and Diversity " +
            "that will be open and welcoming to all marginalized student groups.");

        // BAM 2.0 - Demand #2
        demands.Add("We demand a considerable uptick in the number of racially diverse students, faculty, and staff populations of Miami University's Oxford Campus through: The student " +
            "population reflecting the demographics of comparable Ohio public universities: six percent Black students, six percent Hispanic, four percent Asian (domestic), two percent " +
            "Native American by 2025.Increase the percentage of ethnically diverse faculty to 25 percent by 2028. The expansion of the Cincinnati Scholars Program to Cleveland, Cincinnati, " +
            "Dayton and Chicago by 2022. The reconstruction of the Bridges program by implementing qualifications for attending the program based on marginalized identities, including first " +
            "generation for academic year 2018-19.");

        // BAM 2.0 - Demand #3
        demands.Add("We demand a comprehensive report from Dr. Ron Scott, Associate Vice President for Institutional Diversity, including: The initiatives and accomplishments" +
            " of his office from academic year 2013-14 through 2017-18. A copy of the job description of Dr. Ron Scott, Associate Vice President for Institutional Diversity.");

        // BAM 2.0 - Demand #4
        demands.Add("We demand Miami University revise the 'Discrimination & Harassment' section of the Code of Conduct.");

        // BAM 2.0 - Demand #5
        demands.Add("We demand Miami University creates a sanctioned adjudication process to address acts of racism and discrimination with clearly defined disciplinary actions " +
            "for reported students, staff and faculty.");

        // BAM 2.0 - Demand #6
        demands.Add("We demand that Miami University send a notice of adjudication to the student responsible for posting the offensive, derogatory and direct remarks via Snapchat " +
            "regarding Black students who were engaging in lawful protest on March 26, 2018.");

        // BAM 2.0 - Demand #7
        demands.Add("We demand incident reporting forms to be more accessible and visible to students, faculty and staff by: Having the Dean of Student's office include discussion on " +
            "discrimination and harassment during their summer orientation session revolving around community expectations, personal responsibility, and student safety. Training faculty, " +
            "staff and student employees to navigate incident reporting forms. Requiring Resident Assistants to inform residents of the process of accessing incident reporting forms. " +
            "Spelling out the 'Office of Equity and Equal Opportunity' on the MyMiami homepage as a Quick Link. Administering a quick and efficient means of educating all current Miami " +
            "students -- on all campuses -- on how they can access this link.");
        
        // BAM 2.0 - Demand #8
        demands.Add("We demand the implementation of diversity and inclusion training for all incoming students, current students, and faculty and " +
            "staff on all Miami University campuses (Oxford, Hamilton, Middletown, West Chester and Luxembourg).");

        // BAM 2.0 - Demand #9
        demands.Add("We demand transparency in the form of monthly reports from the university on updates of the following initiatives: Dr. Coates' 2017 Presidential " +
            "Task force on Diversity and Inclusion The search process for the next Dean of Students. Council on Diversity and Inclusion (CODI). BAM 2.0 demands. This demand " +
            "shall be emailed out to the student body by the last day of every month of the academic school year.");

        // BAM 2.0 - Demand #10
        demands.Add("We demand a meeting with the following administrators: Dr. Greg Crawford, University President. Dr. Ron Scott, Associate Vice President for Institutional " +
            "Diversity. Dr. Jayne Brownell, Vice President of Student Affairs. Dr. Mike Curme, Dean of Students. Dr. Kelley Kimple, Director of the Office of Diversity Affairs");

        // Shuffle the lists simulataneouslys
        for (int i = 0; i < audio_clips.Count; i++)
        {
            var randomIndex = Random.Range(0, audio_clips.Count - 1);
            var tmp = audio_clips[i];
            audio_clips[i] = audio_clips[randomIndex];
            audio_clips[randomIndex] = tmp;
        }

    }

    void Update()
    {
        // Calculate the distance from the camera to the microphone
        float distance = (transform.position - ar_camera.transform.position).magnitude;

        // If close enough, show the demand
        if (renderer.isVisible && distance <= 1.0f)
        {
            text.GetComponent<TMP_Text>().SetText(demands[0]);
            popup.SetActive(true);
        }
    }

    void ChangePosition()
    {
        //transform.position = new Vector3(Random.Range(-18.6944f, 18.6944f), -1.0f, Random.Range(-7.0104f, 7.0104f));
        transform.position = new Vector3(Random.Range(-3.0f, 3.0f), -1.0f, Random.Range(-3.0f, 3.0f)); //Random.Range(-180.0f, 180.0f)
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Random.Range(-180.0f, 180.0f), transform.rotation.eulerAngles.z);
    }
}
