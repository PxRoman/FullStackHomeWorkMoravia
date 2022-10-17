import React, {useEffect, useState} from "react";
import {apiGet} from "../../api/apiRequests";
import {TranslationJob} from "../../model/TranslationJob";
import {Link} from "react-router-dom";

const TranslationList = ({refreshData, setRefreshData}: {refreshData: boolean, setRefreshData: React.Dispatch<React.SetStateAction<boolean>>}) => {
    const [jobs, setJobs] = useState<TranslationJob[]>([]);

    useEffect(() => {
        const jobsStorage = sessionStorage .getItem("jobs");
        if(jobsStorage !== null && !refreshData) {
            setJobs(JSON.parse(jobsStorage));

            return;
        }

        apiGet("jobs/GetJobs").then(response => {
            if(response !== undefined) {
                sessionStorage .setItem("jobs", JSON.stringify(response));
                setJobs(response)
                setRefreshData(false);
            }
        })
    }, []);

    return (
        <table>
            <thead>
            <tr>
                <th>Id</th>
                <th>Customer Name</th>
                <th>Price</th>
                <th>Status</th>
            </tr>
            </thead>
            <tbody>
            {jobs.map((value: TranslationJob) =>
                <tr key={value.id}>
                    <td><Link to={value.id.toString()}><button>{value.id}</button></Link></td>
                    <td>{value.customerName}</td>
                    <td>{value.price}</td>
                    <td>{value.status}</td>
                </tr>
            )}
            </tbody>
        </table>
    );
}

export default  TranslationList;