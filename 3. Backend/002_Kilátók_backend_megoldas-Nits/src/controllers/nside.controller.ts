import { Request, Response, Router } from "express";
import Controller from "../interfaces/controller.interface";
import nsideModel from "./nside.model";
import onesideModel from "./oneside.model";

export default class nsideController implements Controller {
    public router = Router();
    private nsideM = nsideModel;
    private onesideM = onesideModel;

    constructor() {
        this.router.patch("/api/viewpoints/:id", this.modifyPATCH);
    }

    private modifyPATCH = async (req: Request, res: Response) => {
        try {
            const id = req.params.id;
            const body = req.body;
            // Nem a megoldás része, de lehet feladat:
            // if (body?.location) {
            //     const loc = await this.onesideM.findById(body.location);
            //     if (!loc) {
            //         res.status(404).send({ message: `location=${body.location} azonosítóval nem létezik hegység!` });
            //         return;
            //     }
            // }
            const updatedDoc = await this.nsideM.findByIdAndUpdate(id, body, { new: true, runValidators: true });
            if (updatedDoc) {
                res.send(updatedDoc);
            } else {
                res.status(404).send({ message: `"${id} azonosítóval nem létezik kilátó!` });
            }
        } catch (error) {
            res.status(400).send({ message: error.message });
        }
    };
}
