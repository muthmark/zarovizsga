import { Request, Response, Router } from "express";
import Controller from "../interfaces/controller.interface";
import onesideModel from "./oneside.model";

export default class nsideController implements Controller {
    public router = Router();
    private onesideM = onesideModel;

    constructor() {
        this.router.get("/api/locations/:locationName/viewPoints", this.getByLocationName);
    }

    private getByLocationName = async (req: Request, res: Response) => {
        try {
            const ln = req.params.locationName;
            const document = await this.onesideM.find({ locationName: ln }).populate("viewpoints", "-_id");
            if (document && document.length > 0) {
                res.send(document);
            } else {
                res.status(404).send({ message: "Ebben a hegységben nem találtam kilátót." });
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
}
