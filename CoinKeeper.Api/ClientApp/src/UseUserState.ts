import {useState} from "react";
import {Api} from "./api/Api";
import {UserStateViewModel} from "./models/User/UserStateViewModel";

export default async function useUserState() {
    async function getToken(): Promise<UserStateViewModel> {
        return await Api.IsAuthenticated();
    }

    const [userState, setUserState] = useState<UserStateViewModel>(await getToken());

    const saveUserState = async () => {
        console.log(getToken())
        setUserState(await getToken());
    }

    return {
        setUserState: saveUserState,
        userState
    }
}