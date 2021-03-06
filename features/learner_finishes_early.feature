Feature: Provider earnings and payments where learner completes earlier than planned and is funded by levy

    The earnings and payment rules for early completions are the same as for learners finishing on time, except that the completion payment is earned earlier.

    Background:
        Given the apprenticeship funding band maximum for each learner is 17000
        And levy balance > agreed price for all months

    Scenario: A DAS learner, levy available, learner finishes one month early
        When an ILR file is submitted with the following data:
            | learner type       | agreed price | start date | planned end date | actual end date | completion status |
            | programme only DAS | 15000        | 01/09/2017 | 08/09/2018       | 08/08/2018      | completed         |
        Then the provider earnings and payments break down as follows:
            | Type                       | 09/17 | 10/17 | 11/17 | ... | 08/18 | 09/18 |
            | Provider Earned Total      | 1000  | 1000  | 1000  | ... | 4000  | 0     |
            | Provider Earned from SFA   | 1000  | 1000  | 1000  | ... | 4000  | 0     |
            | Provider Paid by SFA       | 0     | 1000  | 1000  | ... | 1000  | 4000  |
            | Levy account debited       | 0     | 1000  | 1000  | ... | 1000  | 4000  |
            | SFA Levy employer budget   | 1000  | 1000  | 1000  | ... | 4000  | 0     |
            | SFA Levy co-funding budget | 0     | 0     | 0     | ... | 0     | 0     |
        And the transaction types for the payments are:
            | Transaction type | 10/17 | 11/17 | ... | 08/18 | 09/18 |
            | On-program       | 1000  | 1000  | ... | 1000  | 1000  |
            | Completion       | 0     | 0     | ... | 0     | 3000  |
            | Balancing        | 0     | 0     | ... | 0     | 0     |

    Scenario: A DAS learner, levy available, learner finishes two months early
        When an ILR file is submitted with the following data:
            | learner type       | agreed price | start date | planned end date | actual end date | completion status |
            | programme only DAS | 15000        | 01/09/2017 | 08/09/2018       | 08/07/2018      | completed         |
        Then the provider earnings and payments break down as follows:
            | Type                       | 09/17 | 10/17 | 11/17 | ... | 07/18 | 08/18 |
            | Provider Earned Total      | 1000  | 1000  | 1000  | ... | 5000  | 0     |
            | Provider Earned from SFA   | 1000  | 1000  | 1000  | ... | 5000  | 0     |
            | Provider Paid by SFA       | 0     | 1000  | 1000  | ... | 1000  | 5000  |
            | Levy account debited       | 0     | 1000  | 1000  | ... | 1000  | 5000  |
            | SFA Levy employer budget   | 1000  | 1000  | 1000  | ... | 5000  | 0     |
            | SFA Levy co-funding budget | 0     | 0     | 0     | ... | 0     | 0     |
        And the transaction types for the payments are:
            | Transaction type | 10/17 | 11/17 | ... | 07/18 | 08/18 |
            | On-program       | 1000  | 1000  | ... | 1000  | 1000  |
            | Completion       | 0     | 0     | ... | 0     | 3000  |
            | Balancing        | 0     | 0     | ... | 0     | 1000  |
