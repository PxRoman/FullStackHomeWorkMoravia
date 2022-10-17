import React, {useEffect, useState} from "react";
import {Link, useNavigate, useParams} from "react-router-dom";
import {apiPut} from "../../api/apiRequests";

const TranslationEdit = ({setRefreshData}: {setRefreshData: React.Dispatch<React.SetStateAction<boolean>>}) => {
    const [jobStatus, setJobStatus] = useState<string>("");
    const navigate = useNavigate();

    let params = useParams();
    let id: number = params.id ? parseInt(params.id) : 0;

    useEffect(() => {
        const jobsStorage = sessionStorage .getItem("jobs");
        if(jobsStorage !== null) {
            let parsed = JSON.parse(jobsStorage)[id-1]

            setJobStatus(parsed.status);
        }
    }, [])

    const HandleSaveButtonClick = () => {
        apiPut("jobs/UpdateJobStatus", {jobId: id, translatorId: 0, newStatus: jobStatus})
            .then(response => {
                setRefreshData(true);
                navigate("/translation-list", {replace: true});
            });
    }

    const HandleStatusChange = (event: any) => {
        setJobStatus(event.target.value);
    }

    return (
        <React.Fragment>
            <h1>Id: {id}</h1>
            <label>Job Status: </label>
            <input type="text" defaultValue={jobStatus} onChange={HandleStatusChange}/>
            <Link to="/translation-list">
                <button type="button">Return</button>
            </Link>
            <button onClick={HandleSaveButtonClick} type="button">Save</button>
        </React.Fragment>

    )
}

export default  TranslationEdit;